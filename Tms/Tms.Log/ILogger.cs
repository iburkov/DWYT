﻿using System;
using System.Runtime.CompilerServices;
#pragma warning disable 1573

namespace Tms.Log
{
    /// <summary>
    ///     Manages logging.
    /// </summary>
    /// <remarks>
    ///     This is a facade for the different logging subsystems.
    ///     It offers a simplified interface that follows IOC patterns
    ///     and a simplified priority/level/severity abstraction.
    /// </remarks>
    public interface ILogger
    {
        /// <summary>
        ///     Determines if messages of priority "debug" will be logged.
        /// </summary>
        /// <value>True if "debug" messages will be logged.</value>
        bool IsDebugEnabled { get; }

        /// <summary>
        ///     Determines if messages of priority "error" will be logged.
        /// </summary>
        /// <value>True if "error" messages will be logged.</value>
        bool IsErrorEnabled { get; }

        /// <summary>
        ///     Determines if messages of priority "fatal" will be logged.
        /// </summary>
        /// <value>True if "fatal" messages will be logged.</value>
        bool IsFatalEnabled { get; }

        /// <summary>
        ///     Determines if messages of priority "info" will be logged.
        /// </summary>
        /// <value>True if "info" messages will be logged.</value>
        bool IsInfoEnabled { get; }

        /// <summary>
        ///     Determines if messages of priority "warn" will be logged.
        /// </summary>
        /// <value>True if "warn" messages will be logged.</value>
        bool IsWarnEnabled { get; }

        /// <summary>
        ///     Logs a debug message. The message will be constructed only if the <see cref="IsDebugEnabled" /> is true.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Debug(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        ///     Logs a debug message with lazily constructed message. The message will be constructed only if the
        ///     <see cref="IsDebugEnabled" /> is true.
        /// </summary>
        /// <param name="messageFactory"></param>
        void Debug(Func<string> messageFactory,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        ///     Logs a debug message. The message will be constructed only if the <see cref="IsDebugEnabled" /> is true.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to log</param>
        void Debug(string message, Exception exception,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        ///     Logs a debug message. The message will be constructed only if the <see cref="IsDebugEnabled" /> is true.
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void DebugFormat(string format, params object[] args);

        /// <summary>
        ///     Logs an error message. The message will be constructed only if the <see cref="IsErrorEnabled" /> is true.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Error(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        ///     Logs an error message with lazily constructed message. The message will be constructed only if the
        ///     <see cref="IsErrorEnabled" /> is true.
        /// </summary>
        /// <param name="messageFactory"></param>
        void Error(Func<string> messageFactory,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        ///     Logs an error message. The message will be constructed only if the <see cref="IsErrorEnabled" /> is true.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to log</param>
        void Error(string message, Exception exception,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        ///     Logs an error message. The message will be constructed only if the <see cref="IsErrorEnabled" /> is true.
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void ErrorFormat(string format, params object[] args);

        /// <summary>
        ///     Logs a fatal message. The message will be constructed only if the <see cref="IsFatalEnabled" /> is true.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Fatal(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        ///     Logs a fatal message with lazily constructed message. The message will be constructed only if the
        ///     <see cref="IsFatalEnabled" /> is true.
        /// </summary>
        /// <param name="messageFactory"></param>
        void Fatal(Func<string> messageFactory,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        ///     Logs a fatal message. The message will be constructed only if the <see cref="IsFatalEnabled" /> is true.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to log</param>
        void Fatal(string message, Exception exception,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        ///     Logs a fatal message. The message will be constructed only if the <see cref="IsFatalEnabled" /> is true.
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void FatalFormat(string format, params object[] args);

        /// <summary>
        ///     Logs an info message. The message will be constructed only if the <see cref="IsInfoEnabled" /> is true.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Info(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        ///     Logs a info message with lazily constructed message. The message will be constructed only if the
        ///     <see cref="IsInfoEnabled" /> is true.
        /// </summary>
        /// <param name="messageFactory"></param>
        void Info(Func<string> messageFactory,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        ///     Logs an info message. The message will be constructed only if the <see cref="IsInfoEnabled" /> is true.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to log</param>
        void Info(string message, Exception exception,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        ///     Logs an info message. The message will be constructed only if the <see cref="IsInfoEnabled" /> is true.
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void InfoFormat(string format, params object[] args);

        /// <summary>
        ///     Logs a warn message. The message will be constructed only if the <see cref="IsWarnEnabled" /> is true.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Warn(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        ///     Logs a warn message with lazily constructed message. The message will be constructed only if the
        ///     <see cref="IsWarnEnabled" /> is true.
        /// </summary>
        /// <param name="messageFactory"></param>
        void Warn(Func<string> messageFactory,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        ///     Logs a warn message. The message will be constructed only if the <see cref="IsWarnEnabled" /> is true.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to log</param>
        void Warn(string message, Exception exception,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        ///     Logs a warn message. The message will be constructed only if the <see cref="IsWarnEnabled" /> is true.
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void WarnFormat(string format, params object[] args);
    }
}