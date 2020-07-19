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
    public class CycledDynamicArray<T>: DynamicArray<T>
    {
        public void Move()
        {
            if (CurIndex == array.Length - 1)
            {
                Reset();
            }
            CurIndex++;
        }
        public override bool MoveNext()
        {
            while (true)
            {
                Move();
            }
        }
        
    }
}
