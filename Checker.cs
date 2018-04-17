using System.Collections.Generic;

namespace DenatiKata
{
    public class Checker
    {
        public Checker(Vin vinNumber)
        {
            VinNumber = vinNumber;
        }
        public Vin VinNumber { get; set; }

        public bool IsValidDenati()
        {
            return
                IsValidCountryCode() &&
                IsValidManufacturerCode() &&
                IsValidVehicleCode() &&
                IsValidSecurityCode() &&
                IsValidYearCode() &&
                IsValidPlantCode();
        }

        public bool IsCoveredUnderWarranty()
        {
            return
                IsValidCountryCode() &&
                IsValidManufacturerCode() &&
                IsValidWarrantyVehicleCode() &&
                IsValidSecurityCode() &&
                IsValidWarrantyVehicleCode() &&
                IsValidPlantCode();
        }

        public bool IsValidCountryCode()
        {
            var problemYears = new List<string>()
            {
               "1", "2", "3", "4"
            };

            return problemYears.Contains(VinNumber.CountryCode);
        }

        public bool IsValidManufacturerCode()
        {
            return VinNumber.ManufacturerCode == "DN";
        }

        public bool IsValidVehicleCode()
        {
            return VinNumber.VehicleCode.Substring(4, 1) == "Z";
        }

        public bool IsValidWarrantyVehicleCode()
        {
            var problemVehicles = new List<string>()
            {
                "HE80Z", "JB70Z"
            };

            return problemVehicles.Contains(VinNumber.VehicleCode);
        }

        public bool IsValidSecurityCode()
        {
            return VinNumber.SecurityCode == "Z";
        }

        public bool IsValidYearCode()
        {
            var validYear = new List<string>
            {
                "B", "C", "D", "E", "F"
            };

            return validYear.Contains(VinNumber.YearCode);
        }

        public bool IsValidPlantCode()
        {
            if (VinNumber.CountryCode == "1")
            {
                return VinNumber.PlantCode == "A" || VinNumber.PlantCode == "B";
            }

            if (VinNumber.CountryCode == "2")
            {
                return VinNumber.PlantCode == "A" || VinNumber.CountryCode == "B";
            }

            if (VinNumber.CountryCode == "3")
            {
                return VinNumber.PlantCode == "A" || VinNumber.PlantCode == "B";
            }

            if (VinNumber.CountryCode == "4")
            {
                return VinNumber.PlantCode == "A" || VinNumber.PlantCode == "B";
            }
            return false;
        }
    }
}
