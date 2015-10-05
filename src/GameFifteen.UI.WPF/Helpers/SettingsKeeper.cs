using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteen.UI.WPF.Helpers
{
    public static class SettingsKeeper
    {
        private static string rows;
        private static string cols;
        private static string tile;
        private static string pattern;
        private static string mover;


        public static string Rows
        {
            get
            {
                return rows;
            }

            set
            {
                rows = value;
            }
        }

        public static string Cols
        {
            get
            {
                return cols;
            }

            set
            {
                cols = value;
            }
        }

        public static string Tile
        {
            get
            {
                return tile;
            }

            set
            {
                tile = value;
            }
        }

        public static string Pattern
        {
            get
            {
                return pattern;
            }

            set
            {
                pattern = value;
            }
        }

        public static string Mover
        {
            get
            {
                return mover;
            }

            set
            {
                mover = value;
            }
        }
    }
}
