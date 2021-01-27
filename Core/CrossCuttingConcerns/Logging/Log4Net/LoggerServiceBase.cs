using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerServiceBase
    {
        private ILog _log;
        public LoggerServiceBase(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            if (Environment.GetEnvironmentVariable("RUN_MODE") == "DOCKER")
            {              
                xmlDocument.Load(File.OpenRead("Log4net.config"));
                xmlDocument.SelectSingleNode("//log4net/appender/connectionString/@value").Value = "Server=mysqlteknim;PORT=3306 ;Database=teknim;Uid=root;Pwd=5421345;";
                //var str = xmlDocument.SelectSingleNode("//log4net/appender/connectionString/@value").Value;
                ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
                log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);
                _log = LogManager.GetLogger(loggerRepository.Name, name);

            }
            else
            {
                ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
                var assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                xmlDocument.Load(new FileInfo(Path.Combine(assemblyFolder, "log4net.config")).FullName);
                xmlDocument.SelectSingleNode("//log4net/appender/connectionString/@value").Value= "Server=127.0.0.1;PORT=9345 ;Database=teknim;Uid=root;Pwd=5421345;";
                //var str = xmlDocument.SelectSingleNode("//log4net/appender/connectionString/@value").Value;
                XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);
                _log = LogManager.GetLogger(loggerRepository.Name, name);
            }

            //log4net.Util.LogLog.InternalDebugging = true;
        }

        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
                _log.Info(logMessage);
        }
        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
                _log.Debug(logMessage);
        }
        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
                _log.Error(logMessage);
        }
        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
                _log.Fatal(logMessage);
        }
        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
                _log.Warn(logMessage);
        }
    }
}
