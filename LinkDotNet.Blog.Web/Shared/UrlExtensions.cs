﻿using System;

namespace LinkDotNet.Blog.Web.Shared
{
    public static class UrlExtensions
    {
        public static string ToAbsoluteUrl(this string url, string baseUrl)
        {
            if (IsAbsoluteUrl(url))
            {
                return url;
            }

            var successful = Uri.TryCreate(new Uri(baseUrl, UriKind.Absolute), new Uri(url, UriKind.RelativeOrAbsolute), out var uri);
            return successful ? uri.ToString() : url;
        }

        private static bool IsAbsoluteUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }
    }
}