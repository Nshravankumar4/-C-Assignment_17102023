using System;
using System.Collections.Generic;


public interface IActivity
{
    void Execute();
    void Rollback();
}


public class WorkflowEngine
{
    public List<IActivity> Activities { get; set; }

    public void ExecuteWorkflow()
    {
        foreach (var activity in Activities)
        {
            try
            {
                activity.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing activity: {ex.Message}");
                RollbackActivities(Activities, Activities.IndexOf(activity));
                break;
            }
        }
    }

    private void RollbackActivities(List<IActivity> activities, int rollbackIndex)
    {
        for (int i = rollbackIndex; i >= 0; i--)
        {
            activities[i].Rollback();
        }
    }
}
