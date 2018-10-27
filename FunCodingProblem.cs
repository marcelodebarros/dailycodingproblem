using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class FunCodingProblem
	{
		static public bool CanCoverAllPoints(double[][] coordinates, int n, double s)
		{
			double minx = Double.MaxValue;
			double maxx = Double.MinValue;
			double miny = Double.MaxValue;
			double maxy = Double.MinValue;

			for (int i = 0; i < n; i++)
			{
				minx = (coordinates[i][0] < minx) ? coordinates[i][0] : minx;
				maxx = (coordinates[i][0] > maxx) ? coordinates[i][0] : maxx;
				miny = (coordinates[i][1] < miny) ? coordinates[i][1] : miny;
				maxy = (coordinates[i][1] > maxy) ? coordinates[i][1] : maxy;
			}

			double deltax = maxx - minx;
			double deltay = maxy - miny;

			return (deltax <= 3 * s) && (deltay <= 3 * s);
		}
	}
}
