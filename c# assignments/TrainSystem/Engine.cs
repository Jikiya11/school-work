using System.ComponentModel.Design;

namespace TrainSystem
{
    public class Engine
    {
        #region Attributes

        // HorsePower
        private int _HorsePower;

        // Model
        private String _Model = "Unknown";

        // Serial number
        private String _SerialNumber = "Unknown";

        // Weight
        private int _Weight;

        // In Service
        private bool _InService;

        #endregion

        #region Properties

        /// <summary>
        /// Get and set for HorsePower, on set it validates input
        /// </summary>
        public int HorsePower
        {
            get { return _HorsePower; }

            set
            {
                if (value < 3500 || value > 5500)
                {
                    throw new ArgumentOutOfRangeException($"HorsePower must be between 3500 and 5500");
                }
                else if (!Utilities.InHundreds(value))
                {
                    throw new ArgumentException($"{value} is not divisible by 100");
                }
                if (InService is true)
                {
                    throw new Exception("Engine is in service");
                }
                _HorsePower = value;
            }

        }

        /// <summary>
        /// Get and set for InService
        /// </summary>
        public bool InService
        {
            get { return _InService; }
            set { _InService = value; }
        }

        /// <summary>
        /// Get and set for Model, validates input and trims it on set
        /// </summary>
        public String Model
        {
            get { return _Model; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Value cannot be null or whitespace");
                }
                _Model = value.Trim();
            }
        }

        /// <summary>
        /// Get and set for SerialNumber, validates input and trims on set
        /// </summary>
        public String SerialNumber
        {
            get { return _SerialNumber; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Value cannot be null or whitespace");
                }
                _SerialNumber = value.Trim();
            }
        }

        /// <summary>
        /// Get and set for Weight, validates input
        /// </summary>
        public int Weight
        {
            get { return _Weight; }
            set
            {
                if (Utilities.IsPositiveNonZero(value) is false)
                {
                    throw new ArgumentException($"{value} is not a positive int above 0");
                }
                else if (Utilities.InHundreds(value) is false)
                {
                    throw new ArgumentException($"{value} is not divisible by 100");
                }
                if (InService is true)
                {
                    throw new Exception("Engine is in service");
                }
                _Weight = value;
            }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Greedy constructor, sets all values to input parameters
        /// </summary>
        /// <param name="model"></param>
        /// <param name="serialNumber"></param>
        /// <param name="weight"></param>
        /// <param name="horsePower"></param>
        public Engine(String model, String serialNumber, int weight, int horsePower)
        {
            HorsePower = horsePower;
            Model = model;
            SerialNumber = serialNumber;
            Weight = weight;
            InService = true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a string representation of an Engine object
        /// </summary>
        /// <returns>string value of an Engine object</returns>
        public override string ToString()
        {   
            return $"{Model},{SerialNumber},{Weight},{HorsePower},{InService}";
        }

        #endregion
    }
}

