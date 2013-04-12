Test Credentials Demo
==============

The Test Credentials Demo is a sample that demostrates how to build automated integration tests using Twilio [Test Credentials](http://www.twilio.com/docs/api/rest/test-credentials) and Visual Studio 2012.

Prerequisites
--------------
In order to run this sample you will need to ensure you have the following prerequisites installed:

* Visual Studio 2012 or later

Configuration
--------------
This sample comes with two projects:

- TestCredentialsDemo - Contains several sample classes uses to execute tests against
- TestCredentialsDemo.Tests - Contains the unit test classes

In order for all tests to pass you will need to update the *_accountSid* and *_authToken* variables in each test class with your Twilio Test Credentials

You can find your Test Credentials under the Dev Tools tab of your [Twilio dashboard](https://www.twilio.com/user/account/developer-tools/test-credentials)

More Info
-------------
The full documentation for Test Credentials is available here: http://www.twilio.com/docs/api/rest/test-credentials

Built for explanation & demo purposes, April 2013.
