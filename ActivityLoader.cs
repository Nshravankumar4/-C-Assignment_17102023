using System;
using System.Collections.Generic;
using System.Reflection;


public class ActivityLoader
{
    public static IActivity LoadActivity(string assemblyName, string activityName, Dictionary<string, string> parameters)
    {
        Assembly activityAssembly = Assembly.LoadFrom(assemblyName); 

        Type activityType = activityAssembly.GetType(activityName); 

        if (activityType != null)
        {
            IActivity activity = (IActivity)Activator.CreateInstance(activityType); 


            foreach (var param in parameters)
            {
                PropertyInfo property = activityType.GetProperty(param.Key);
                if (property != null)
                {
                    object value = Convert.ChangeType(param.Value, property.PropertyType);
                    property.SetValue(activity, value);
                }
            }

            return activity;
        }

        return null; 
    }
}
