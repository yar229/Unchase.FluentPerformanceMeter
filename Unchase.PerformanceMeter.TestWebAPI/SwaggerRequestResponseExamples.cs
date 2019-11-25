﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Swashbuckle.AspNetCore.Filters;

namespace Unchase.PerformanceMeter.TestWebAPI
{
    internal class SwaggerRequestResponseExamples
    {
        private class PerformanceInfoExample : IPerformanceInfo
        {
            public List<MethodCallInfo<MethodInfo>> MethodCalls { get => new List<MethodCallInfo<MethodInfo>>(); set { } }

            public List<MethodCallsCount<MethodInfo>> TotalActivity { get => new List<MethodCallsCount<MethodInfo>>(); set { } }

            public List<MethodCallsCount<MethodInfo>> CurrentActivity { get => new List<MethodCallsCount<MethodInfo>>(); set { } }

            public DateTime UptimeSince { get => DateTime.Now.AddHours(-1); set { } }

            public string ClassName { get => "SomeClasssName"; set { } }

            public List<string> MethodNames { get => new List<string>(); set { } }
        }

        internal class GetPerformanceInfoResponse200Example : IExamplesProvider
        {
            /// <summary>
            /// Получить примеры.
            /// </summary>
            /// <returns>Возвращает <see cref="StandartResponse"/>.</returns>
            object IExamplesProvider.GetExamples()
            {
                return new PerformanceInfoExample();
            }
        }
    }
}