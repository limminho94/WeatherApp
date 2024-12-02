using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weatherApp.Model;

namespace weatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        public WeatherVM()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                Selectedcity = new City
                {
                    LocalizedName = "서울"
                };

                currentConditions = new CurrentConditions
                {
                    WeatherText = "Partly cloudy",
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = 21
                        }
                    }
                };
            }
        }

        //[1] 시나리오: 도시 검색을 요청(query)한다.
        private string query;
        public string Query
        {
            get { return query; }
            // [2] Property가 변경되면, 
            set
            {
                query = value;
                // OnPropertyChanged 함수에서
                OnPropertyChanged(nameof(Query));
            }
        }

        //[1] 시나리오: CurrentConditions 현재 날씨 정보가 업데이트된다.
        private CurrentConditions currentCondition;
        public CurrentConditions currentConditions
        {
            get { return currentCondition; }
            // [2] Property가 변경되면,
            set
            {   
                currentCondition = value;
                // OnPropertyChanged 함수에서
                OnPropertyChanged(nameof(currentConditions));
            }
        }
        //[1] 시나리오: City 정보가 업데이트 된다.
        private City selectedcity;

        public City Selectedcity
        {
            get { return selectedcity; }
            // [2] Property가 변경되면,
            set
            {
                selectedcity = value;
                // OnPropertyChanged 함수에서
                OnPropertyChanged(nameof(Selectedcity));
            }
        }

        // [4] 이벤트 핸들러가 동작하면, 
        // XAML에 바인딩 되어있는 모든 UI컨트롤에 해당 query 값이 업데이트 된다.
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            // [3] PropertyChanged 이벤트를 실행한다.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
