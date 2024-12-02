﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using weatherApp.Model;

namespace weatherApp.ViewModel.Helpers
{
    class AccuWeatherHelper
    {
        public const string API_KEY = "u1exIoud0BZrm5tAq26Zjcabu24RbGyj";

        public const string BASE_URL = "http://dataservice.accuweather.com/";

        public const string LANGUAGE = "ko-kr";

        public const string AUTOCOMPLETE_ENDPOINT =
            "locations/v1/cities/autocomplete?apikey={0}&q={1}&language={2}";

        public const string CURRENT_CONDITIONS_ENDPOINT =
            "currentconditions/v1/{0}?apikey={1}&language={2}";

        public static async Task<List<City>> GetCities(string query)
        {
            // API Json 결과에서 City 객체 타입 데이터를 List에 담습니다.
            List<City> cities = new List<City>();

            // API 요청 URL 을 설정합니다.
            string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query, LANGUAGE);

            // HttpClient 에서
            using (HttpClient clnt = new HttpClient())
            {
                // url로 API 요청을 request 하고, reponse 값을 cities 리스트에 할당합니다.
                var res = await clnt.GetAsync(url);
                string json = await res.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditions(string citikey)
        {
            // API Json 결과에서 CurrentConditions 객체 타입 데이터를 List에 담습니다.
            CurrentConditions currentConditions = new CurrentConditions();

            // API 요청 URL 을 설정합니다.
            string url = BASE_URL + string.Format(CURRENT_CONDITIONS_ENDPOINT, citikey, API_KEY, LANGUAGE);

            // HttpClient 에서
            using (HttpClient clnt = new HttpClient())
            {
                // url로 API 요청을 request 하고, reponse 값을 CurrentConditions 리스트에 할당합니다.
                var res = await clnt.GetAsync(url);
                string json = await res.Content.ReadAsStringAsync();
                currentConditions = JsonConvert.DeserializeObject<List<CurrentConditions>>(json).FirstOrDefault();
            }
            return currentConditions;
        }
    }
}
