﻿using BasicUsage.Attributes;
using System;
using System.Threading.Tasks;

namespace BasicUsage
{
    public class AsyncModifyReturnValue : MoDataContainer
    {
        [ExceptionHandle]
#if NET461 || NET6
        public async Task<string> ExceptionAsync(bool throwException = true)
#else
        public async ValueTask<string> ExceptionAsync(bool throwException = true)
#endif
        {
            await Task.Yield();
            if (throwException) throw new InvalidOperationException(nameof(ExceptionAsync));

            return Guid.NewGuid().ToString();
        }

        [ExceptionHandle]
#if NET461 || NET6
        public async Task<int> ExceptionWithUnboxAsync(bool throwException = true)
#else
        public async ValueTask<int> ExceptionWithUnboxAsync(bool throwException = true)
#endif
        {
            await Task.Yield();
            if (throwException) throw new InvalidOperationException(nameof(ExceptionWithUnboxAsync));

            return GetHashCode();
        }

        [ExceptionHandle]
#if NET461 || NET6
        public async Task<double> ExceptionUnhandledAsync(bool throwException = true)
#else
        public async ValueTask<double> ExceptionUnhandledAsync(bool throwException = true)
#endif
        {
            await Task.Yield();
            if (throwException) throw new InvalidOperationException(nameof(ExceptionUnhandledAsync));

            return GetHashCode() * 1.0 / nameof(ExceptionUnhandledAsync).Length;
        }

        [ReturnValueReplace]
#if NET461 || NET6
        public async Task<string> SucceededAsync(object[] args)
#else
        public async ValueTask<string> SucceededAsync(object[] args)
#endif
        {
            await Task.Yield();
            return Guid.NewGuid().ToString() + "|" + string.Join("|", args);
        }

        [ReturnValueReplace]
#if NET461 || NET6
        public async Task<int> SucceededWithUnboxAsync()
#else
        public async ValueTask<int> SucceededWithUnboxAsync()
#endif
        {
            await Task.Yield();
            return int.MaxValue % nameof(SucceededWithUnboxAsync).Length;
        }

        [ReturnValueReplace]
#if NET461 || NET6
        public async Task<double> SucceededUnrecognizedAsync()
#else
        public async ValueTask<double> SucceededUnrecognizedAsync()
#endif
        {
            await Task.Yield();
            return int.MaxValue * 1.0 / nameof(SucceededUnrecognizedAsync).Length;
        }
    }
}