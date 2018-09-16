using DSC.SmartMarket.BusinessLogic.IoC;
using DSC.SmartMarket.Model;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;

namespace DSC.SmartMarket.BusinessLogic.Validation
{
    public abstract class ValidationBase : UnityBase, IValidationBase
    {
        #region Atributo(s)
        private object m_operation;
        private object m_target;
        #endregion Atributo(s)

        #region Propriedade(s)
        protected virtual object Operation
        {
            get
            {
                return m_operation;
            }
        }

        protected virtual object Target
        {
            get
            {
                return m_target;
            }
        }
        #endregion Propriedade(s)

        #region Construtor(es)
        protected ValidationBase()
        {
            m_target = null;
            m_operation = null;
        }

        protected ValidationBase(object target, object operation)
        {
            m_target = target;
            m_operation = operation;
        }
        #endregion Construtor(es)

        #region Método(s)
        protected virtual Resultado Validate(object target, object operation)
        {
            m_target = target;
            m_operation = operation;
            return Validate();
        }

        public virtual Resultado Validate()
        {
            Resultado resultado;
            try
            {
                resultado = new Resultado(true);
                resultado.Adicionar(ValidateFields());
                resultado.Adicionar(ValidateFieldsRules());
                resultado.Adicionar(ValidateRules());
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        protected virtual Resultado ValidateFields()
        {
            Resultado resultado;
            try
            {
                var validator = ValidationFactory.CreateValidator(m_target.GetType(), m_operation.ToString());
                var validationResults = validator.Validate(Target);
                resultado = new Resultado(true);
                validationResults.ConsolidarResultadosValidacao(resultado);
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        protected virtual Resultado ValidateFieldsRules()
        {
            return new Resultado(true);
        }

        protected virtual Resultado ValidateRules()
        {
            return new Resultado(true);
        }
        #endregion Método(s)
    }

    public abstract class ValidationBase<T, O> : ValidationBase, IValidationBase<T, O>
        where T : class
        where O : struct, IConvertible
    {
        #region Propriedade(s)
        protected new O Operation
        {
            get
            {
                return (O)base.Operation;
            }
        }

        protected new T Target
        {
            get
            {
                return (T)base.Target;
            }
        }
        #endregion Propriedade(s)

        #region Método(s)
        public Resultado Validate(T target, O operation)
        {
            return base.Validate(target, operation);
        }

        protected override Resultado ValidateFields()
        {
            Resultado resultado;
            try
            {
                var validator = ValidationFactory.CreateValidator<T>(Operation.ToString());
                var validationResults = validator.Validate(Target);
                resultado = new Resultado(true);
                validationResults.ConsolidarResultadosValidacao(resultado);
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }
        #endregion Método(s)

        #region Construtor(es)
        public ValidationBase()
            : base() { }

        public ValidationBase(T target, O operation)
            : base(target, operation) { }
        #endregion Construtor(es)
    }
}
