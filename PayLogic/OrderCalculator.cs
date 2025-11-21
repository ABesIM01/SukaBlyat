using System;
using System.Collections.Generic;
using System.Linq;

namespace WinFormsApp2.PayLogic
{
    public class OrderCalculator
    {
        // Словник з цінами на послуги
        private readonly Dictionary<string, decimal> servicePrices;

        public OrderCalculator()
        {
            // Можна пізніше завантажити ціни з бази або конфігу
            servicePrices = new Dictionary<string, decimal>
            {
                { "Таксі", 150m },
                { "Ескорт", 500m },
                { "Охорона", 300m },
                { "Доставка", 100m }
            };
        }

        /// <summary>
        /// Повертає ціну за конкретну послугу
        /// </summary>
        public decimal GetPrice(string service)
        {
            if (servicePrices.TryGetValue(service, out decimal price))
                return price;
            return 0m;
        }

        /// <summary>
        /// Підраховує загальну суму для вибраних послуг
        /// </summary>
        public decimal CalculateTotal(IEnumerable<string> selectedServices)
        {
            if (selectedServices == null) return 0m;
            return selectedServices.Sum(s => GetPrice(s));
        }

        /// <summary>
        /// Можна отримати список всіх доступних послуг і їх цін
        /// </summary>
        public IReadOnlyDictionary<string, decimal> GetAllServices() => servicePrices;
    }
}
