using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Xml.Serialization;
using Facebook.Properties;
using Facebook.Utility;

namespace Facebook.Entity
{
	public enum Gender
	{
		Unknown,
		Male,
		Female
	}

	public enum LookingFor
	{
		Unknown,
		Friendship,
		ARelationship,
		Dating,
		RandomPlay,
		WhateverIcanget,
		Networking
	}

	public enum RelationshipStatus
	{
		Unknown,
		Single,
		InARelationship,
		InAnOpenRelationship,
		Engaged,
		Married,
		ItsComplicated
	}

	public enum PoliticalView
	{
		Unknown,
		VeryLiberal,
		Liberal,
		Moderate,
		Conservative,
		VeryConservative,
		Apathetic,
		Libertarian,
		Other
	}

	[Serializable]
	public class User
	{
		#region Private Data

		private readonly Status _status = new Status();		
		
		#endregion Private Data

		#region Properties

		/// <summary>
		/// Facebook unique identifier of the user
		/// </summary>
		public string UserId { get; set; }

		/// <summary>
		/// User's first name
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// User's last name
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// User's name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// User's birthday
		/// </summary>
		public DateTime? Birthday { get; set; }

		/// <summary>
		/// User's birthday
		/// </summary>
		public DateTime ProfileUpdateDate { get; set; }

		/// <summary>
		/// Free form text describing this user
		/// </summary>
		public string AboutMe { get; set; }

		/// <summary>
		/// count of notes
		/// </summary>
		public int NotesCount { get; set; }

		/// <summary>
		/// Number of messages on the wall
		/// </summary>
		public int WallCount { get; set; }

		/// <summary>
		/// </summary>
		public Status Status
		{
			get { return _status; }
		}

		#endregion Properties

		public User()
		{
			Name = string.Empty;
			LastName = string.Empty;
			FirstName = string.Empty;
			UserId = string.Empty;			
			AboutMe = string.Empty;
		}
	}
}