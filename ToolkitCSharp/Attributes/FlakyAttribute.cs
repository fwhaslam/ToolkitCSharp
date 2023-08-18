using System;

namespace SpaceGameModel.Tools {

	/// <summary>
	/// Use this to mark Test classes and Test methods as being unreliable.
	/// Sometimes we have tests which do not always succeed, but are necessary nonetheless.
	/// This allows the developer to explain that the test is flaky and why it is necessary.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class FlakyAttribute : Attribute {

		internal string reason;

		public FlakyAttribute(string reason) {
			this.reason = reason;
		}
	}
}
