using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string workflowFilePath = @"C:\Path\To\Your\Workflow.xml"; 

        WorkflowXmlParser parser = new WorkflowXmlParser();
        List<IActivity> workflowActivities = parser.ParseWorkflow(workflowFilePath);

        WorkflowEngine engine = new WorkflowEngine();
        engine.Activities = workflowActivities;
        engine.ExecuteWorkflow();
    }
}
