using System.Collections.Generic;

namespace Kiwi
{
    public class Solver
    {
        /// <summary>
        /// Add a constraint to the solver.
        /// </summary>
        /// <param name="constraint"></param>
        /// <exception cref="DuplicateConstraint">
        /// The given constraint has already been added to the solver.
        /// </exception>
        /// <exception cref="UnsatisfiableConstraint">
        /// The given constraint is required and cannot be satisfied.
        /// </exception>
        public void AddConstraint(Constraint constraint)
        {
        }

        /// <summary>
        /// Remove a constraint from the solver.
        /// </summary>
        /// <param name="constraint"></param>
        /// <exception cref="UnknownConstraint">The given constraint has not been added to the solver.</exception>
        public void RemoveConstraint(Constraint constraint)
        {
        }

        /// <summary>
        /// Test whether a constraint has been added to the solver.
        /// </summary>
        /// <param name="constraint"></param>
        /// <returns></returns>
        public bool HasConstraint(Constraint constraint)
        {
            return false;
        }

        /// <summary>
        /// Add an edit variable to the solver.
        /// This method should be called before the `suggestValue` method is
        /// used to supply a suggested value for the given edit variable.
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="strength"></param>
        /// <exception cref="DuplicateEditVariable">The given edit variable has already been added to the solver.</exception>
        /// <exception cref="BadRequiredStrength">The given strength is >= required.</exception>
        public void AddEditVariable(Variable variable, double strength)
        {
        }

        /// <summary>
        /// Remove an edit variable from the solver.
        /// </summary>
        /// <param name="variable">The variable to remove.</param>
        /// <exception cref="UnknownEditVariable">The given edit variable has not been added to the solver.</exception>
        public void RemoveEditVariable(Variable variable)
        {
            new Dictionary<int,int>().Add();
            ///// <summary>Adds the specified key and value to the dictionary.</summary>
            ///// <param name="key">The key of the element to add.</param>
            ///// <param name="value">The value of the element to add. The value can be null for reference types.</param>
            ///// <exception cref="T:System.ArgumentNullException"><paramref name="key">key</paramref> is null.</exception>
            ///// <exception cref="T:System.ArgumentException">An element with the same key already exists in the <see cref="T:System.Collections.Generic.Dictionary`2"></see>.</exception>
        }

        /// <summary>
        /// Test whether an edit variable has been added to the solver.
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public bool HasEditVariable(Variable variable)
        {
            return false;
        }


        /// <summary>
        /// Suggest a value for the given edit variable.
        /// This method should be used after an edit variable has been added to
        /// the solver in order to suggest the value for that variable. After
        /// all suggestions have been made, the `solve` method can be used to
        /// update the values of all variables.
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        /// <exception cref="UnknownEditVariable">The given edit variable has not been added to the solver.</exception>
        public void SuggestValue(Variable variable, double value)
        {
        }

        /// <summary>
        /// Update the values of the external solver variables. 
        /// </summary>
        public void UpdateVariables()
        {
        }

        /// <summary>
        /// Reset the solver to the empty starting condition.
        /// This method resets the internal solver state to the empty starting
        /// condition, as if no constraints or edit variables have been added.
        /// This can be faster than deleting the solver and creating a new one
        /// when the entire system must change, since it can avoid unecessary
        /// heap(de)allocations.
        /// </summary>
        public void Reset()
        {
        }

        /// <summary>
        /// Dump a representation of the solver internals to stdout.
        /// </summary>
        public void Dump()
        {
        }
    }
}