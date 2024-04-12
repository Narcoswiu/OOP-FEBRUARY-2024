using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string name;
        private int stamina;
        private List<string> conqueredPeaks;

        protected Climber(string name, int stamina)
        {
            this.Name = name;
            Stamina = stamina;
            this.conqueredPeaks = new List<string>();
        }

        public string Name
        {
            get => name;

           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public int Stamina
        {
            get => stamina;

           protected set
            {
                if (value > 10)
                {
                    value = 10;
                }
                else if (value < 0)
                {
                    value = 0;

                }
                else
                {
                    stamina = value;
                }
               
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks => conqueredPeaks.AsReadOnly();  


        public void Climb(IPeak peak)
        {
            if (!conqueredPeaks.Contains(peak.Name))
            {
                this.conqueredPeaks.Add(peak.Name);
            }

            int tempStamina = 0;

            if (peak.DifficultyLevel == "Extreme")
            {
                tempStamina += 6;
            }
            else if (peak.DifficultyLevel == "Hard")
            {
                tempStamina += 4;
            }
            else
            {
                tempStamina += 2;
            }

            this.Stamina -= tempStamina;
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            sb.Append("Peaks conquered: ");

            if (this.conqueredPeaks.Count > 0)
            {
                sb.AppendLine($"{ConqueredPeaks.Count}");
            }
            else
            {
                sb.Append("no peaks conquered");
            }

            return sb.ToString().Trim();
        }
    }
}
