using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeBlue.Desafio.Models;
using Microsoft.EntityFrameworkCore;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web;

namespace BeBlue.Desafio.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly BeBlueDesafio _beBlue;

        public AlbumController(BeBlueDesafio beBlue)
        {
            _beBlue = beBlue;
        }

        [HttpGet]
        public List<Album> Get()
        {
            return _beBlue.Albuns.ToList();
        }

        [HttpGet("{id}")]
        public Album Get(int id)
        {
            return _beBlue.Albuns.Find(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Album album)
        {
            _beBlue.Albuns.Add(album);
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("Álbum adicionado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]Album album)
        {
            _beBlue.Entry(album).State = EntityState.Modified;
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("Álbum alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _beBlue.Albuns.Remove(_beBlue.Albuns.Find(id));
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("Álbum removido com sucesso!");
        }

        [HttpGet]
        public List<Album> GetAlbunsPaginado(int idGenero, int pagina, int qtdPagina)
        {
            List<Album> _albuns = _beBlue.Albuns.ToList().Where(d => d.IdGenero == idGenero).OrderBy(x => x.Titulo).ToList();
            return _albuns.Skip(pagina * qtdPagina).Take(qtdPagina).ToList();
        }

        [HttpGet]
        public List<CatalogoSpotify> GetTitulos(string pesquisa)
        {
            var result = new Search();
            List<CatalogoSpotify> _catalogoSpotify = new List<CatalogoSpotify>();

            var auth = new ClientCredentialsAuth()
            {
                // Client Id
                ClientId = "0987e02401e443b6b1f7e4c2c0f97bfe",
                ClientSecret = "4aad0fb4ea1044f29eccaa5295825f4d",
                Scope = Scope.UserReadPrivate
            };

            // Recupera o Token do spotifywebapi object
            Token token = auth.DoAuth();

            var spotify = new SpotifyWebAPI()
            {
                TokenType = token.TokenType,
                AccessToken = token.AccessToken,
                UseAuth = true
            };

            // Pesquisa o álbum pelo artista, ou gênero
            var albumResultado = spotify.SearchItems(pesquisa, SearchType.All);


            string albumID;
            FullAlbum albumResult;

            result.sortedList = new System.Collections.Generic.SortedList<FullAlbum, int>(new AlbumPopularityComparer());

            if (albumResultado.Artists.Items.Count > 0)
            {
                var artistObj = albumResultado.Artists.Items[0];

                var albums = spotify.GetArtistsAlbums(artistObj.Id, limit: 300);
                bool albumInList = false;

                for (int i = 0; i < albums.Items.Count; ++i)
                {
                    albumID = albums.Items[i].Id;
                    albumResult = spotify.GetAlbum(albumID);

                    if (result.sortedList.Count > 0)
                    {
                        for (int j = 0; j < result.sortedList.Count; ++j)
                        {
                            if (albumResult.Name == result.sortedList.ElementAt(j).Key.Name)
                            {
                                albumInList = true;
                            }
                        }

                        if (albumInList != true)
                        {
                            if (result.sortedList.ContainsKey(albumResult) != true)
                            {
                                result.sortedList.Add(albumResult, albumResult.Popularity);
                            }
                        }

                        albumInList = false;
                    } // if
                    else
                    {   
                        result.sortedList.Add(albumResult, albumResult.Popularity);
                    }
                } // for

                result.Artist = artistObj;
            } // if
            else
            {   
                return null;
            }

            for(int i = 0; i < result.sortedList.Count; i++)
            {
                _catalogoSpotify.Add(new CatalogoSpotify()
                {
                    Album = result.sortedList.ElementAt(i).Key.Name,
                    Artista = result.sortedList.ElementAt(i).Key.Artists.First().Name,
                    Genero = "teste",//result.sortedList.ElementAt(i).Key.Genres.First().ToString(),
                    ImageUrl = result.sortedList.ElementAt(i).Key.Images.First().Url,
                });
            }

            return _catalogoSpotify;
        }
    }
}
