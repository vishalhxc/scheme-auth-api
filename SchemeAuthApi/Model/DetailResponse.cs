using System;
using System.Collections.Generic;

namespace SchemeAuthApi.Model
{
    public class DetailResponse<T>
    {
        public int Status { get; set; }
        public T Detail { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DetailResponse<T> response &&
                   Status == response.Status &&
                   EqualityComparer<T>.Default.Equals(Detail, response.Detail);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Status, Detail);
        }

        public static bool operator ==(DetailResponse<T> left, DetailResponse<T> right)
        {
            return EqualityComparer<DetailResponse<T>>.Default.Equals(left, right);
        }

        public static bool operator !=(DetailResponse<T> left, DetailResponse<T> right)
        {
            return !(left == right);
        }
    }
}
