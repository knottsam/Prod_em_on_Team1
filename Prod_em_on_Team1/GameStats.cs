using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Prod_em_on_Team1
{
    public class GameStats : Timer
    {
        public double RecordTime { get; set; }
        public string TestStatistic { get; set; }
    }
}
