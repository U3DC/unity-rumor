﻿using Exodrifter.Rumor.Engine;
using Exodrifter.Rumor.Expressions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Exodrifter.Rumor.Nodes
{
	/// <summary>
	/// A statement is a standalone expression which will be evaluated.
	/// </summary>
	[Serializable]
	public sealed class Statement : Node, ISerializable
	{
		/// <summary>
		/// The expression to evaluate.
		/// </summary>
		public readonly Expression expression;

		/// <summary>
		/// Creates a new Statement node.
		/// </summary>
		/// <param name="text">
		/// The text to append to the dialog.
		/// </param>
		public Statement(Expression expression)
		{
			this.expression = expression;
		}

		public override IEnumerator<RumorYield> Run(Engine.Rumor rumor)
		{
			expression.Evaluate(rumor.Scope);
			yield return null;
		}

		#region Serialization

		public Statement(SerializationInfo info, StreamingContext context)
		{
			expression = (Expression)info.GetValue("expression", typeof(Expression));
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("expression", expression, typeof(Expression));
		}

		#endregion
	}
}