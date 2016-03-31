using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using FluentAssertions;
using Tms.Configuration.Implementation;
using Xunit;

namespace Tms.Configuration.Tests.FileConfig
{
    public class FileConfigSectionTest
    {
        [Fact]
        public void Ctor()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new FileConfigSection("TestSettings");

            action.ShouldNotThrow("Ctor should never throw exception");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("TestSettings")]
        public void Name_Verification(string name)
        {
            //Arrange
            var configSection = new FileConfigSection(name);

            //Act and Assert
            configSection.Name.Should().Be(name);
        }

        [Theory]
        //[InlineData("TestSettings")]
        [InlineData("appSettings")]
        public void Settings_Found(string name)
        {
            //Arrange
            var configSection = new FileConfigSection(name);

            //Act 
            var settings = configSection.Settings;

            //Assert
            settings.Should().NotBeNull().And.NotBeEmpty();
        }

        [Fact]
        public void Settings_Check()
        {
            //Arrange
            const string name = "TestSettings";

            var configSection = new FileConfigSection(name);

            //Act 
            var settings = configSection.Settings;

            //Assert
            settings.Should().ContainKey("FirstParam").And.ContainValue("One");
            settings.Should().ContainKey("SecondParam").And.ContainValue("Two");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("404")]
        public void Settings_No_Section_Found(string name)
        {
            //Arrange
            var configSection = new FileConfigSection(name);

            //Act 
            IDictionary<string, string> settings = null;
            Action settingsAction = () => settings = configSection.Settings;

            //Assert
            settingsAction.ShouldThrow<ConfigurationErrorsException>();
            settings.Should().BeNull();
        }
    }
}