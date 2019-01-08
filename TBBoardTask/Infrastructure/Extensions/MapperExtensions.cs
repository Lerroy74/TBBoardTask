using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace TBBoardTask.Infrastructure.Extensions
{
    public static class MapperExtensions
    {
        public static TDest MapTo<TDest>(this object source)
        {
            return (TDest)Mapper.Map(source, source.GetType(), typeof(TDest));
        }

        public static object MapTo(this object source, Type tDest)
        {
            return Mapper.Map(source, source.GetType(), tDest);
        }

        public static TDest MapTo<TDest, TSource>(this TSource source, TDest destination)
        {
            return Mapper.Map(source, destination);
        }

        public static IEnumerable<TDest> MapEachTo<TDest>(this IEnumerable<object> source)
        {
            return source.MapTo<IEnumerable<TDest>>();
        }
    }
}
