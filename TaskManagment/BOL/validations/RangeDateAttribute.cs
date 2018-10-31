using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BOL.validations
{
    class RangeDateAttribute : ValidationAttribute
    {
        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty("EndDate");
            object propertyValue = property.GetValue(instance);
            //Boolean.TryParse(propertyValue.ToString(), out bool EndDate);
            //?????   return (propertyValue > propertyValue1) ? true : false;
            return new ValidationResult("the EndDate must be after the StartDate");
        }
    }
}
