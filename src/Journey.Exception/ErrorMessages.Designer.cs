﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Journey.Exceptions {
    using System;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessages() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Journey.Exceptions.ErrorMessages", typeof(ErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a A data da atividade deve ester entre o inicio e o fim da viagem..
        /// </summary>
        public static string DateActivityBeetwenTripDates {
            get {
                return ResourceManager.GetString("DateActivityBeetwenTripDates", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a A data do fim da viagem deve ser maior que a data atual..
        /// </summary>
        public static string EndDateGreaterThanNow {
            get {
                return ResourceManager.GetString("EndDateGreaterThanNow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a A data do fim da viagem não pode ser menor que a data de inicio da viagem..
        /// </summary>
        public static string EndDateLessThanOrEqualToStartDate {
            get {
                return ResourceManager.GetString("EndDateLessThanOrEqualToStartDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Não foi possivel incluir dados no bando de dados..
        /// </summary>
        public static string ErrorIncludeDatabase {
            get {
                return ResourceManager.GetString("ErrorIncludeDatabase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Erro interno do Servidor..
        /// </summary>
        public static string IntenalServerError {
            get {
                return ResourceManager.GetString("IntenalServerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a A descrição é obrigatória..
        /// </summary>
        public static string NameEmpty {
            get {
                return ResourceManager.GetString("NameEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a A descrição deve ter entre 4 e 100 caracteres..
        /// </summary>
        public static string NameLegth {
            get {
                return ResourceManager.GetString("NameLegth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a {0} com Id: {1} não foi encontrad{2}..
        /// </summary>
        public static string NotFound {
            get {
                return ResourceManager.GetString("NotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a RequestRegister{0}Json.
        /// </summary>
        public static string RequestRegisterNullExeption {
            get {
                return ResourceManager.GetString("RequestRegisterNullExeption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Dados da {0} são obrigatórios..
        /// </summary>
        public static string RequestRegisterNullExeptionMessage {
            get {
                return ResourceManager.GetString("RequestRegisterNullExeptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a A data de inicio da viagem deve ser maior que a data atual..
        /// </summary>
        public static string StartDateGreaterThanNow {
            get {
                return ResourceManager.GetString("StartDateGreaterThanNow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a A data de inicio da viagem não pode ser maior que a data de fim da viagem..
        /// </summary>
        public static string StartDateLessThanOrEqualToEndDate {
            get {
                return ResourceManager.GetString("StartDateLessThanOrEqualToEndDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a O status da atividade deve ser  0 - Pendete ou 1 - Finalizado..
        /// </summary>
        public static string StatusActivityMessage {
            get {
                return ResourceManager.GetString("StatusActivityMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Not Found Error.
        /// </summary>
        public static string TypeErrorNotFound {
            get {
                return ResourceManager.GetString("TypeErrorNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Unknown Error.
        /// </summary>
        public static string TypeErrorUnknown {
            get {
                return ResourceManager.GetString("TypeErrorUnknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Validation Error.
        /// </summary>
        public static string TypeErrorValidation {
            get {
                return ResourceManager.GetString("TypeErrorValidation", resourceCulture);
            }
        }
    }
}
