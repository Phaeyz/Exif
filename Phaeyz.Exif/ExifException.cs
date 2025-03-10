﻿namespace Phaeyz.Exif;

/// <summary>
/// This exception is thrown if there is a serialization or deserialization issue.
/// </summary>
/// <param name="message">
/// Message details regarding the exception.
/// </param>
public class ExifException(string message) : Exception(message) { }
