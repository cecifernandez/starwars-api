using swBackend.Interfaces;
using swBackend.Models;
using System.Linq;

namespace swBackend.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly HttpClient _httpClient;

        private readonly InfoRepository _infoRepository;

        public CharacterRepository(IHttpClientFactory httpClientFactory, InfoRepository infoRepository)
        {
            _httpClient = httpClientFactory.CreateClient();
            _infoRepository = infoRepository;
        }

        public async Task<IEnumerable<CharacterModel>> GetAllCharacters()
        {
            var characters = new List<CharacterModel>();
            
            var filmsUrlToTitleMap = await _infoRepository.GetInfo<FilmResponseModel>("https://swapi.dev/api/films/");

            var characterPlanet = await _infoRepository.GetInfo<PlanetResponseModel>("https://swapi.dev/api/planets/");

            var characterSpecies = await _infoRepository.GetInfo<SpeciesResponseModel>("https://swapi.dev/api/species/");
            
            var characterVehicles = await _infoRepository.GetInfo<VehicleResponseModel>("https://swapi.dev/api/vehicles/");
            
            var characterStarships = await _infoRepository.GetInfo<StarshipResponseModel>("https://swapi.dev/api/starships/");


            var apiUrl = "https://swapi.dev/api/people/";
            //ResponseModel response;
            ResponseWrapperModel<CharacterModel> response;

            
            do
            {
                response = await _httpClient.GetFromJsonAsync<ResponseWrapperModel<CharacterModel>>(apiUrl);
                

                if (response != null)
                {
                    foreach (var character in response.Results)
                    {
                        // Map film URLs to film titles
                        character.Films = character.Films.Select(filmUrl =>
                            filmsUrlToTitleMap.ContainsKey(filmUrl)
                                ? filmsUrlToTitleMap[filmUrl]
                                : "Unknown Film").ToList();

                        character.Planet = characterPlanet.ContainsKey(character.Planet)
                                ? characterPlanet[character.Planet]
                                : "Unknown";

                        character.Species = character.Species.Select(speciesUrl =>
                            characterSpecies.ContainsKey(speciesUrl)
                                ? characterSpecies[speciesUrl]
                                : "Unknown species").ToList();

                        character.Vehicles = character.Vehicles.Select(vehicleUrl =>
                            characterVehicles.ContainsKey(vehicleUrl)
                                ? characterVehicles[vehicleUrl]
                                : "Unknown").ToList();

                        character.Starships = character.Starships.Select(starshipUrl =>
                            characterStarships.ContainsKey(starshipUrl)
                                ? characterStarships[starshipUrl]
                                : "Unknown").ToList();
                    }

                    characters.AddRange(response.Results);

                    // Update apiUrl with the next page URL for pagination
                    apiUrl = response.Next;
                }
            } while (response != null && !string.IsNullOrEmpty(response.Next));

            return characters;
        }

        //public async Task<Dictionary<string, string>> GetUrl<T>(string api) where T : FilmResponseModel
        //{
        //    var toUrl = new Dictionary<string, string>();
        //    var response = await _httpClient.GetFromJsonAsync<T>(api);

        //    if(response?.Results != null)
        //    {
        //        foreach(var ent in response.Results)
        //        {
        //            toUrl[ent.Url] = ent.Title;
                    
        //        }
        //    }

        //    return toUrl;
        //}

        //public async Task<Dictionary<string, string>> GetInfo<T>(string api) where T : IHasUrlAndName
        //{
        //    var toUrl = new Dictionary<string, string>();
        //    //var response = await _httpClient.GetFromJsonAsync<ResponseWrapperModel<T>>(api);
        //    ResponseWrapperModel<T> response;

        //    do {
        //         response = await _httpClient.GetFromJsonAsync<ResponseWrapperModel<T>>(api);

        //        if (response?.Results != null)
        //        {
        //            foreach (var ent in response.Results)
        //            {
        //                toUrl[ent.Url] = ent.Name;
        //                //toUrl[ent.Url] = ent.Species;
        //                //toUrl[ent.Url] = ent.Starships;
        //                //toUrl[ent.Url] = ent.Vehicles;
        //            }
        //            api = response?.Next;
        //        }
        //    } while (response != null && !string.IsNullOrEmpty(response.Next)) ;
            

        //    return toUrl;
        //}

        //public async Task<Dictionary<string, string>> GetFilmsUrlToTitleMap()
        //{
        //    var filmsUrlToTitle = new Dictionary<string, string>();

        //    var apiUrl = "https://swapi.dev/api/films/";
        //    var response = await _httpClient.GetFromJsonAsync<FilmResponseModel>(apiUrl);

        //    if (response?.Results != null)
        //    {
        //        foreach (var film in response.Results)
        //        {

        //            filmsUrlToTitle[film.Url] = film.Title;
        //        }
        //    }

        //    return filmsUrlToTitle;
        //}
    }
}
