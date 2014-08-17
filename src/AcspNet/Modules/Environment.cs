﻿namespace AcspNet.Modules
{
	/// <summary>
	/// Site environment properties, initialized from <see cref="IAcspNetSettings" />
	/// </summary>
	public sealed class Environment : IEnvironment
	{
		private readonly string _sitePhysicalPath;

		/// <summary>
		/// Initializes a new instance of the <see cref="Environment"/> class.
		/// </summary>
		/// <param name="sitePhysicalPath">The site physical path.</param>
		/// <param name="settings">The settings.</param>
		public Environment(string sitePhysicalPath, IAcspNetSettings settings)
		{
			sitePhysicalPath = sitePhysicalPath.Replace("\\", "/");

			if (!sitePhysicalPath.EndsWith("/"))
				sitePhysicalPath = sitePhysicalPath + "/";

			_sitePhysicalPath = sitePhysicalPath;

			TemplatesPath = settings.DefaultTemplatesPath;
			SiteStyle = settings.DefaultStyle;
			MasterTemplateFileName = settings.DefaultMasterTemplateFileName;
		}

		/// <summary>
		/// Site current templates directory relative path
		/// </summary>
		public string TemplatesPath { get; set; }

		/// <summary>
		/// Site current templates directory physical path
		/// </summary>
		public string TemplatesPhysicalPath
		{
			get
			{
				return _sitePhysicalPath + TemplatesPath + "/";
			}
		}

		/// <summary>
		/// Site current style
		/// </summary>
		public string SiteStyle { get; set; }

		/// <summary>
		/// Gets or sets the current master page template file name
		/// </summary>
		/// <value>
		/// The name of the master page template file
		/// </value>
		public string MasterTemplateFileName { get; set; }
	}
}