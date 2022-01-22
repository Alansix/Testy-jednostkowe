using System;
using Xunit;

namespace TestyRownanieKwadratowe
{
    public class UnitTest1
    {
        [Fact]
        public void RozwiazanieRownaniaKwadratowegoTest1()
        {
            var rownanie = new UnitTest1();
            var wynik = rownanie.RozwiazanieRownaniaKwadratowego(-2, 3, -1);
            Assert.Equal((0.5, 1), wynik);
        }

        //seria testów sprawdzaj¹ca funkcjê przy delta > 0
        [Theory]
        [InlineData(-2, 3, -1, 0.5, 1)]
        [InlineData(4, 0, -1, 0.5, -0.5)]
        [InlineData(1, 5, 6, -2, -3)]
        [InlineData(1, -5, -6, 6, -1)]
        [InlineData(1, -3, -4, 4, -1)]
        [InlineData(1, 0, -4, 2, -2)]
        public void RozwiazanieRownaniaKwadratowego_DwaPierwiastki_Pass(double a, double b, double c, double x1, double x2)
        {
            var rownanie = new UnitTest1();
            var wynik = rownanie.RozwiazanieRownaniaKwadratowego(a, b, c);
            Assert.Equal((x1, x2), wynik);
        }

        //seria testów sprawdzaj¹ca funkcjê przy delta = 0
        [Theory]
        [InlineData(2, 4, 2, -1)]
        [InlineData(2, -8, 8, 2)]
        [InlineData(1, 2, 1, -1)]
        public void RozwiazanieRownaniaKwadratowego_JedenPierwiastek_Pass(double a, double b, double c, double x1)
        {
            var rownanie = new UnitTest1();
            var wynik = rownanie.RozwiazanieRownaniaKwadratowego(a, b, c);
            Assert.Equal((x1, x1), wynik);
        }

        //seria testów sprawdzaj¹ca funkcjê czy zwraca argumant typu: double, double
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(5, 710, 20)]
        [InlineData(29, 10, 100)]
        public void RozwiazanieRownaniaKwadratowego_ZwracanyTyp_Pass(double a, double b, double c)
        {
            var rownanie = new UnitTest1();
            var wynik = rownanie.RozwiazanieRownaniaKwadratowego(a, b, c);
            Assert.IsType < (double, double)> (wynik);
        }


        //seria testów sprawdzaj¹ca funkcjê przy delta < 0
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(0, 0, 0)]
        [InlineData(2, 0, 100)]
        public void RozwiazanieRownaniaKwadratowego_BrakPierwiastekow_Pass(double a, double b, double c)
        {
            var rownanie = new UnitTest1();
            var wynik = rownanie.RozwiazanieRownaniaKwadratowego(a, b, c);
            Assert.Equal((double.NaN, double.NaN), wynik);
        }

        //seria testów sprawdzaj¹ca funkcjê przy braku argumentow
        [Theory]
        [InlineData(1, 5, null)]
        [InlineData(0, null, null)]
        [InlineData(null, null, null)]
        public void RozwiazanieRownaniaKwadratowego_BrakArgumentu_Pass(double a, double b, double c)
        {
            var rownanie = new UnitTest1();
            var wynik = rownanie.RozwiazanieRownaniaKwadratowego(a, b, c);
            Assert.NotNull(wynik);
            
        }

        (double, double) RozwiazanieRownaniaKwadratowego(double a, double b, double c)
        {
            double x1, x2;
            double delta = (b * b) - (4 * a * c);
            x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            return (x1, x2);
        }
    }
}
