using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Reflection;

namespace WinInvestmentTracker.BOL
{
    public class AOPProxy<T> : RealProxy
    {
        private readonly T _decorated;
        private Predicate<MethodInfo> _filter;
        public AOPProxy(T decorated) : base(typeof(T))
        {
            _decorated = decorated;
            _filter = m => true;
        }
        public Predicate<MethodInfo> Filter
        {
            get { return _filter; }
            set
            {
                if (value == null)
                    _filter = m => true;
                else
                    _filter = value;
            }
        }

        public event EventHandler<IMethodCallMessage> BeforeExecute;
        public event EventHandler<IMethodCallMessage> AfterExecute;
        public event EventHandler<IMethodCallMessage> ErrorExecute;

        private void OnBeforExecute(IMethodCallMessage methodCall)
        {
            if(BeforeExecute != null)
            {
                var methodInfo = methodCall.MethodBase as MethodInfo;
                if(_filter(methodInfo))
                {
                    BeforeExecute(this, methodCall);
                }
            }
        }
        private void OnAfterExecute(IMethodCallMessage methodCall)
        {
            if (BeforeExecute != null)
            {
                var methodInfo = methodCall.MethodBase as MethodInfo;
                if (_filter(methodInfo))
                {
                    AfterExecute(this, methodCall);
                }
            }
        }
        private void OnErrorExecute(IMethodCallMessage methodCall)
        {
            if (BeforeExecute != null)
            {
                var methodInfo = methodCall.MethodBase as MethodInfo;
                if (_filter(methodInfo))
                {
                    ErrorExecute(this, methodCall);
                }
            }
        }
        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;
            OnBeforExecute(methodCall);
            try
            {
                var result = methodInfo.Invoke(_decorated, methodCall.InArgs);
                OnAfterExecute(methodCall);
                return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
            }
            catch(Exception e)
            {
                OnErrorExecute(methodCall);
                return new ReturnMessage(e, methodCall);
            }
        }
    }
}