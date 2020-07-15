using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace TASK3_2_1_DYNAMIC_ARRAY
{
    class CycledDynamicArray<T>: DynamicArray<T>
    {
        public override IEnumerator<T> GetEnumerator()
        {
            foreach (T arrayObject in array)
            {
                yield return arrayObject;
            }
        }

    }
}
