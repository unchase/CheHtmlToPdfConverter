﻿using System;
using System.ComponentModel;

namespace CheHtmlToPdfConverter
{
    public class UrlToConvert
    {
        [DisplayName("URL")]
        public string Url { get; set; }
         [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Открыть?")]
        public bool Open { get; set; }

        public UrlToConvert(string url)
        {
            Url = url;
            Name = 
                DateTime.Now.ToShortDateString() + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" +
                DateTime.Now.Second + "(" + Guid.NewGuid() + ")";
            Open = false;
        }

        public UrlToConvert(string url, string name)
        {
            Url = url;
            Name = name;
            Open = false;
        }

        public UrlToConvert(string url, bool open)
        {
            Url = url;
            Name =
                DateTime.Now.ToShortDateString() + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" +
                DateTime.Now.Second + "(" + Guid.NewGuid() + ")";
            Open = open;
        }

        public UrlToConvert(string url, string name, bool open)
        {
            Url = url;
            Name = name;
            Open = open;
        }
    }
}
