using System;
using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace DD.CloudControl.Client.Tests.Utilities
{
	/// <summary>
	/// 	Marks a method as representing an acceptance test case.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	[XunitTestCaseDiscoverer("DD.CloudControl.Client.Tests.Utilities.AcceptanceFactDiscoverer", "DD.CloudControl.Client.Tests")]
	public sealed class AcceptanceFactAttribute
		: Attribute
	{
		/// <summary>
		/// 	Mark the specified method as representing an acceptance test case.
		/// </summary>
		public AcceptanceFactAttribute()
		{
		}
	}

	/// <summary>
	/// 	A test-case discoverer that only returns test cases if the "CC_CLIENT_ACCTEST" environment variable has been set to "1".
	/// </summary>
	public sealed class AcceptanceFactDiscoverer
		: IXunitTestCaseDiscoverer
	{
		/// <summary>
		/// 	Is the CC_CLIENT_ACCTEST environment variable defined and set to "1"?
		/// </summary>
		public static readonly bool IsAccTestEnvironmentVariableDefined = Environment.GetEnvironmentVariable("CC_CLIENT_ACCTEST") == "1";

		/// <summary>
		/// 	The diagnostic message sink used to report test-discovery messages.
		/// </summary>
		readonly IMessageSink _diagnosticMessageSink;

		/// <summary>
		/// 	Create a new <see cref="AcceptanceFactDiscoverer"/>.
		/// </summary>
		/// <param name="diagnosticMessageSink">
		/// 	The diagnostic message sink used to report test-discovery messages.
		/// </param>
		public AcceptanceFactDiscoverer(IMessageSink diagnosticMessageSink)
		{
			if (diagnosticMessageSink == null)
				throw new ArgumentNullException(nameof(diagnosticMessageSink));

			_diagnosticMessageSink = diagnosticMessageSink;
		}

		/// <summary>
		/// 	Discover any test cases represented by the specified method.
		/// </summary>
		/// <param name="discoveryOptions">
		/// 	Discovery options for the current run.
		/// </param>
		/// <param name="testMethod">
		/// 	The test method to examine.
		/// </param>
		/// <param name="factAttribute">
		/// 	The <see cref="AcceptanceFactAttribute"/> for the test method.
		/// </param>
		/// <returns>
		/// 	A sequence of 0 or more test cases.
		/// </returns>
        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
			if (!IsAccTestEnvironmentVariableDefined)
				yield break;

			yield return new XunitTestCase(_diagnosticMessageSink, TestMethodDisplay.ClassAndMethod, testMethod);
        }
    }
}