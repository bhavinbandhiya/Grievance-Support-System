using System;
using System.Data.SqlTypes;

namespace GrievanceSystemDetails.ENT
{
	public class GRI_GrievanceActivityENT
	{
		#region Properties

		protected SqlInt32 _GrievanceActivityID;
		public SqlInt32 GrievanceActivityID
		{
			get { return _GrievanceActivityID; }
			set { _GrievanceActivityID = value; }
		}

		protected SqlInt32 _GrievanceID;
		public SqlInt32 GrievanceID
		{
			get { return _GrievanceID; }
			set { _GrievanceID = value; }
		}

		protected SqlString _GrievanceStatus;
		public SqlString GrievanceStatus
		{
			get { return _GrievanceStatus; }
			set { _GrievanceStatus = value; }
		}

		protected SqlString _GrievanceRemarks;
		public SqlString GrievanceRemarks
		{
			get { return _GrievanceRemarks; }
			set { _GrievanceRemarks = value; }
		}

		protected SqlDateTime _Created;
		public SqlDateTime Created
		{
			get { return _Created; }
			set { _Created = value; }
		}

		protected SqlDateTime _Modified;
		public SqlDateTime Modified
		{
			get { return _Modified; }
			set { _Modified = value; }
		}

		protected SqlInt32 _UserID;
		public SqlInt32 UserID
		{
			get { return _UserID; }
			set { _UserID = value; }
		}

		#endregion Properties

		#region Constructor

		public GRI_GrievanceActivityENT()
		{
			// Default constructor
		}

		#endregion Constructor
	}
}