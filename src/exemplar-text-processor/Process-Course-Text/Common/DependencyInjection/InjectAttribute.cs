using Microsoft.Azure.WebJobs.Description;
using System;

namespace Process.Course.Text.Common.DependencyInjection
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
    }
}