using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodeGenerator.Core.Manager
{
    public static class Classifier
    {
        public static EntityType ClassifyEntity(EntityContainer entity)
        {
            if (entity.Declaration == null) return EntityType.None;

            var (identifier, _, _) = RegexAnalyzer.Declaration(entity.Declaration);

            if (identifier.Contains("exception")) return EntityType.Exception;
            else
            {
                if (identifier.Contains("class"))
                {
                    if (entity.ReturnsBox != null) return EntityType.Method; // las clases no retornan en C#
                    else return EntityType.Class; // existen funciones que no retornan nada
                }
                else return EntityType.Method;
            }
        }
    }
}
