namespace OOPSReview
{
    /// <summary>
    /// This is a class that manages the employment of our company employees
    /// </summary>
    public class Employment
    {
        #region Attributes

        //Employment job title
        private String _Title = "Unknown";
        //Years in this employment role
        private double _Years;
        private SupervisoryLevel _Level;
 
        #endregion

        #region Properties

        public String Title
        {
            //Simple get
            get { return _Title; }

            //Simple set
            set
            {
                //This will cover cases or strings with whitespaces ex. "   "
                //Better than .IsNullOrEmpty
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is required!");
                }
                _Title = value;
            }
        }

        public double Years
        {
            get { return _Years; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Year value {value} is invalid, must be non-negative!");
                }
                _Years = value;
            }
        }

        public DateTime StartDate { get; set; }

        public SupervisoryLevel Level
        {
            get { return _Level; }
            private set
            {
                if (!Enum.IsDefined(typeof(SupervisoryLevel), value))
                {
                    throw new ArgumentException($"Supervisory Level is invalid: {value}");
                }
                _Level = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor for Employment record
        ///
        /// </summary>
        public Employment()
        {
            //Title cannot be null or whitespace
            Title = "unknown";

            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Today;
        }

        public Employment(String title, SupervisoryLevel level, DateTime startDate, double years = 0.0)
        {
            Title = title;
            Level = level;

            CorrectStartDate(startDate);
            if (startDate > DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startDate} is in the future");
            }

            StartDate = startDate;

            if (years > 0.0)
            {
                Years = years;
            }
            else
            {
                TimeSpan span = DateTime.Now - StartDate;
                Years = Math.Round((span.Days / 365.25), 1); // 365.25 is the # of days in a year accounting for leap years
            }
        }

        #endregion

        #region Methods
        //Method signatures: access returnDataType methodName(paramters - optional)

        /// <summary>
        /// Sets our employment responsibility level for this instance
        /// </summary>
        /// <param name="level">The supervisory level enum to set our employment level to</param>
        public void setEmploymentResponsibilityLevel(SupervisoryLevel level)
        {
            Level = level;
        }

        /// <summary>
        /// Returns a string representing this instance as a CSV
        /// Format: Title, Level, MMM,dd,yyyy, Years
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Title},{Level},{StartDate.ToString("MMM,dd,yyyyy")},{Years}";
        }

        /// <summary>
        /// This method validates our start date
        /// </summary>
        /// <param name="startDate">The DateTime to set the startDate to and vallidate</param>
        public void CorrectStartDate(DateTime startDate)
        {
            if (startDate > DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startDate} is in the future");
            }
            StartDate = startDate;

            TimeSpan span = DateTime.Now - StartDate;
            Years = Math.Round((span.Days / 365.25), 1);
        }

        #endregion
    }
}