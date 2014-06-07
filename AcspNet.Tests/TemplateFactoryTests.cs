﻿using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using AcspNet.Modules;
using Moq;
using NUnit.Framework;
using Simplify.Templates;

namespace AcspNet.Tests
{
	[TestFixture]
	public class TemplateFactoryTests
	{
		[TestFixtureSetUp]
		public void SetUpFileSystem()
		{
			var files = new Dictionary<string, MockFileData> {{"Templates/Foo.tpl", "Dummy data"}};

			Template.FileSystem = new MockFileSystem(files, "C:/WebSites/FooSite");
		}

		[Test]
		public void Load_NoCache_TemplateLoadedCorrectly()
		{		
			var tf = new TemplateFactory("C:/WebSites/FooSite/Templates", "en", "en");

			Assert.Throws<ArgumentNullException>(() => tf.Load(null));

			var data = tf.Load("Foo.tpl");
			Assert.AreEqual("Dummy data", data.Get());
		}

		[Test]
		public void Load_WithCache_TemplateLoadedCorrectly()
		{
			var tf = new TemplateFactory("C:/WebSites/FooSite/Templates", "en", "en", true);

			var data = tf.Load("Foo.tpl");
			Assert.AreEqual("Dummy data", data.Get());

			Template.FileSystem = new Mock<IFileSystem>().Object;

			data = tf.Load("Foo.tpl");
			Assert.AreEqual("Dummy data", data.Get());
		}
	}
}