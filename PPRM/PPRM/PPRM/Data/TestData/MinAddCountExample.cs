using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRM.Data.TestData
{
    class MinAddCountExample:IEnumerable
    {
        private const string Title = "Мінімальний (за кількістю доданків) поляризований поліном Ріда - Маллера:";
        private const string Polynom = "F(x̃3)=(00100111)\r\nP[001] F= x2x3 ⊕ x1 ⊕ x1x3    L(P[001] F) = 3";
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { Title, Polynom };

        }
    }
}
