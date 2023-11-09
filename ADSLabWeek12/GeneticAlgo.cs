using System.Collections.Generic;  
using System.Data;  

public class GeneticAlgo
{

    public void runGA(int generations, List<double> data)
    {
        //Write your experiment here
    }
}
public class Individual
{
    public List<int> individual;
    public double fitness;
    public List<Double> data = new List<double>();

    public Individual(List<Double> dataset)
    {
        Random r = new Random();
        data = dataset;
        individual = new List<int>();
        for (int i=0; i<dataset.Count; i++)
        {
            int gene = r.Next(0,2);
            individual.Add(gene);
        }
        calCurrentFit();
    }

    public void calCurrentFit()
    {
        //complete this method
    }

    public double getFitness()
    {
        calCurrentFit();
        return fitness;
    }

    //This method is to avoid from the object gets the reference.
    public Individual deepCopy()
    {
        Individual other = (Individual)this.MemberwiseClone();  
        other.individual = new (individual);  
        other.fitness = fitness;  
        return other;  
    }

    
    public void mutation (double rate)
    {
        Random r = new Random();
       
        if (rate>1.0)
        {
            Console.WriteLine("Rate should be between 0 and 1");
            return;
        }
        else
        {
            //complete this part
        }
        calCurrentFit();
    }

    public void printIndividual()
    {
        for (int i=0; i<individual.Count; i++)
        {
            Console.Write(individual[i]);
            if (i<individual.Count-1)
                Console.Write(",");
        }
        Console.WriteLine("  "+fitness);
    }
}

public class Population
{
    List<Individual> pop = new List<Individual>();
    List<Individual> parents = new List<Individual>();

    public Population(int popSize, List<double> data)
    {
        for(int i=0; i<popSize; i++)
        {
            Individual ind = new Individual(data);
            pop.Add(ind);
        }
        sortPopulation();
        identifyParents();
    
    }

    public void identifyParents()
    {
        for (int i=0; i<2; i++)
        {
            parents.Add(pop[i]);
        }
    }

    public List<Individual> getParents ()
    {
        return parents;
    }

    public void printParents()
    {
        for (int i=0; i<parents.Count; i++)
        {
            parents[i].printIndividual();
        }
    }
    public void addCandidates(Individual c1, Individual c2, Individual mutant)
    {
        pop.Add(c1);
        pop.Add(c2);
        pop.Add(mutant);
    }

    public void sortPopulation()
    {
        List<Individual> res = pop.OrderBy(o=>o.fitness).ToList();
        pop = res.ToList();
    }

    // public Individual getBestIndividual()
    // {
    //     //complete this method
    // }

    // public List<Individual> crossOver (double coRate, List<Individual> parents)
    // {
    //      //complete this method
    // }

    public void printPopulation()
    {
        for (int i=0; i<pop.Count; i++)
        {
            pop[i].printIndividual();
        }
    }

}


// List<Order> SortedList = objListOrder.OrderBy(o=>o.OrderDate).ToList();