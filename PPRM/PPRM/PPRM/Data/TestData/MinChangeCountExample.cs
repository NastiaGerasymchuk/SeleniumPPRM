using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRM.Data.TestData
{
    class MinChangeCountExample:IEnumerable
    {
        private const string Title = "Мінімальні (за кількістю входжень змінних) поляризовані поліноми Ріда - Маллера:";
        private const string Polynom = "F(x̃3)=(00100111)\r\nP[001] F= x2x3 ⊕ x1 ⊕ x1x3    L(P[001] F) = 5\r\n\r\nF(x̃3)=(00110101)\r\nP[011] F= 1 ⊕ x2 ⊕ x1x3 ⊕ x1x2    L(P[011] F) = 5";
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { Title, Polynom };

        }
    }
}
