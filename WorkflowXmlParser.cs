using System;
using System.Collections.Generic;
using System.Xml;


public class WorkflowXmlParser
{
    public List<IActivity> ParseWorkflow(string filePath)
    {
        List<IActivity> activities = new List<IActivity>();

        try
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNodeList activityNodes = doc.SelectNodes("//Activity");

            foreach (XmlNode node in activityNodes)
            {
                string assemblyName = node.Attributes["AssemblyName"].Value;
                string activityName = node.Attributes["Name"].Value;

                Dictionary<string, string> parameters = new Dictionary<string, string>();

                foreach (XmlNode paramNode in node.SelectNodes("Parameters/*"))
                {
                    parameters.Add(paramNode.Name, paramNode.InnerText);
                }

                IActivity activity = ActivityLoader.LoadActivity(assemblyName, activityName, parameters);

                if (activity != null)
                {
                    activities.Add(activity);
                }
                else
                {
                    Console.WriteLine($"Failed to load activity: {activityName}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing the XML file: {ex.Message}");
        }

        return activities;
    }
}
