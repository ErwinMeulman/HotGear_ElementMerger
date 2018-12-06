using Autodesk.Revit.DB;
using System.Collections.Generic;

public class MyFailuresPreProcessor
{
	private string _failureMessage;

	private bool _hasError;

	public string FailureMessage
	{
		get
		{
			return this._failureMessage;
		}
		set
		{
			this._failureMessage = value;
		}
	}

	public bool HasError
	{
		get
		{
			return this._hasError;
		}
		set
		{
			this._hasError = value;
		}
	}

	public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
	{
		IList<FailureMessageAccessor> failureMessages = failuresAccessor.GetFailureMessages();
		if (failureMessages.Count == 0)
		{
			return 0;
		}
		foreach (FailureMessageAccessor item in failureMessages)
		{
			if ((int)item.GetSeverity() == 2)
			{
				this._failureMessage = item.GetDescriptionText();
				this._hasError = true;
				return 1;
			}
			if ((int)item.GetSeverity() == 1)
			{
				failuresAccessor.DeleteWarning(item);
			}
		}
		return 0;
	}
}
