using System;

namespace PluginInterface
{
	public interface IPlugin
	{
		IPluginHost Host {get;set;}
		
		string Name {get;}
		string Description {get;}
		string Author {get;}
		string Version {get;}
		
		object HostObject {get;set;}
		
		void InvokePlugin();
		
		void Initialize();
		void Dispose();
	
	}
	
	public interface IPluginHost
	{
		//void Feedback(string Feedback, IPlugin Plugin);	
	}
}
