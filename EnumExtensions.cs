using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CS.helpers{

public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }

        public static List<KeyValueDto> GetKVP<T>() where T : struct, IConvertible
        {
            var array = Enum.GetValues(typeof(T)).Cast<Enum>();

            return array.Select(a => new KeyValueDto
            {
                Key = Convert.ToInt32(a),
                Value = a.GetAttribute<DisplayAttribute>()?.Name ?? a.ToString()
            }).ToList();
        }
    }
  }
