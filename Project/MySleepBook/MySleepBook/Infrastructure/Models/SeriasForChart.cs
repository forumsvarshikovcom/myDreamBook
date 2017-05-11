using System.Collections.Generic;
using MySleepBook.CustomControls.Chart;

namespace MySleepBook.Infrastructure.Models
{
    public class SeriasForChart
    {
        public DataPointCollection GoodDreamPoints { get; set; }
        public DataPointCollection BadDreamPoints { get; set; }
        public DataPointCollection FreecPoints { get; set; }
    }
}
