﻿using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;


namespace TestAutomationExample.Infra.Driver
{
    public class AppiumDriverManager : IDisposable
    {
        private readonly AndroidDriver<AndroidElement> driver;
        private bool _isDisposed;
        public AppiumDriverManager()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("appium:platformName", "Android");
            appiumOptions.AddAdditionalCapability("appium:deviceName", "emulator-5554");
            appiumOptions.AddAdditionalCapability("appium:automationName", "uiautomator2");
            appiumOptions.AddAdditionalCapability("appium:appPackage", "com.itau.broker");
            appiumOptions.AddAdditionalCapability("appium:appActivity", "com.itau.broker.activity.LoginActivity_");
            
            // Inicialização do driver
            driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723"), appiumOptions);
        }
        public AndroidDriver<AndroidElement> Current => driver;

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            driver?.Dispose();

            _isDisposed = true;
        }
    }
}