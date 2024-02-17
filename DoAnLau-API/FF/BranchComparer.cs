using DoAnLau_API.Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DoAnLau_API.FF
{
    class BranchComparer : IEqualityComparer<Branch>
    {


        public bool Equals(Branch? x, Branch? y)
        {
            return x.branch_Id == y.branch_Id;
        }

   
        public int GetHashCode([DisallowNull] Branch obj)
        {
            return obj.branch_Id.GetHashCode();
        }
    }
}
